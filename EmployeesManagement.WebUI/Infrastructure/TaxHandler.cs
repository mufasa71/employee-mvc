namespace EmployeesManagement.WebUI.Infrastructure
{
    public class ConcreteTaxHandler : TaxHandler {
        public override double HandleTax(double salary) {
            var firstHandler = new FirstTaxHandler();
            var secondHandler = new SecondTaxHandler();
            var thirdHandler = new ThirdTaxHandler();

            firstHandler.SetSuccessor(secondHandler);
            secondHandler.SetSuccessor(thirdHandler);

            return firstHandler.HandleTax(salary);
        }
    }
    public abstract class TaxHandler {
        protected TaxHandler Successor;

        public void SetSuccessor(TaxHandler successor) {
            Successor = successor;
        }

        public abstract double HandleTax(double salary);
    }

    public class FirstTaxHandler : TaxHandler
    {
        public override double HandleTax(double salary) {
            if (salary < 10000) {
                return 10;
            }
            return Successor != null ? Successor.HandleTax(salary) : 0;
        }
    }

    public class SecondTaxHandler : TaxHandler
    {
        public override double HandleTax(double salary) {
            if (salary > 10000 && salary < 25000) {
                return 15;
            }
            return Successor != null ? Successor.HandleTax(salary) : 0;
        }
    }

    public class ThirdTaxHandler : TaxHandler
    {
        public override double HandleTax(double salary) {
            if (salary > 25000) {
                return 25;
            }
            return Successor != null ? Successor.HandleTax(salary) : 0;
        }
    }
}