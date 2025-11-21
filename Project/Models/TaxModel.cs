namespace Project.Models
{
    public class TaxModel
    {
        public string Country { get; set; }
        public decimal Income { get; set; }
        public decimal TaxOwed { get; set; }

        public decimal CalculateTax()
        {
            decimal tax = 0;

            if (Country == "Nigeria")
            {
                // Simplified Nigerian personal income tax (2024–2025)
                if (Income <= 300000) tax = 0;
                else if (Income <= 600000) tax = (Income - 300000) * 0.07m;
                else if (Income <= 1100000) tax = (300000 * 0.07m) + ((Income - 600000) * 0.11m);
                else if (Income <= 1600000) tax = (300000 * 0.07m) + (500000 * 0.11m) + ((Income - 1100000) * 0.15m);
                else if (Income <= 3200000) tax = (300000 * 0.07m) + (500000 * 0.11m) + (500000 * 0.15m) + ((Income - 1600000) * 0.19m);
                else if (Income <= 3200000) tax = (300000 * 0.07m) + (500000 * 0.11m) + (500000 * 0.15m) + (1600000 * 0.19m) + ((Income - 3200000) * 0.21m);
                else tax = (300000 * 0.07m) + (500000 * 0.11m) + (500000 * 0.15m) + (1600000 * 0.19m) + ((Income - 3200000) * 0.24m);
            }
            else if (Country == "United States")
            {
                // Simplified U.S. federal tax brackets (Single filer, 2025)
                if (Income <= 11600) tax = Income * 0.10m;
                else if (Income <= 47150) tax = 1160 + ((Income - 11600) * 0.12m);
                else if (Income <= 100525) tax = 5426 + ((Income - 47150) * 0.22m);
                else if (Income <= 191950) tax = 17426 + ((Income - 100525) * 0.24m);
                else if (Income <= 243725) tax = 39146 + ((Income - 191950) * 0.32m);
                else if (Income <= 609350) tax = 55634 + ((Income - 243725) * 0.35m);
                else tax = 183647 + ((Income - 609350) * 0.37m);
            }

            TaxOwed = tax;
            return TaxOwed;
        }
    }
}

