using System;

namespace q1logic
{
    public class InterestRepayment
    {
        const int START = 10000;
        const int MINIMUM_REPAYMENT = 5000;
        readonly int _interestRate;
        readonly int _repaymentRate;
        decimal? _totalRepayment;
        int? _steps;

        public InterestRepayment(int interest, int repayment, bool calculate = false)
        {
            _interestRate = interest;
            _repaymentRate = repayment;
            _totalRepayment = null;
            _steps = null;
            if (calculate)
                CalculateTotalRepayment();
        }

        void CalculateTotalRepayment()
        {
            int remainingDebt = START;
            int totalRepayment = 0;
            int previous = remainingDebt;
            _steps = 0;
            while (remainingDebt > 0)
            {
                previous = remainingDebt;
                var step = Calculate(remainingDebt);
                totalRepayment += step.Item2;
                remainingDebt = step.Item1;
                _steps++;
                if(previous <= remainingDebt)
                {
                    _steps = -1;
                    remainingDebt = 0;
                }
            }
            _totalRepayment = (decimal)totalRepayment / 100;
        }

        public int Steps
        {
            get
            {
                if (!_steps.HasValue)
                    CalculateTotalRepayment();
                return _steps.Value;
            }
        }

        public decimal TotalRepayment
        {
            get
            {
                {
                    if (!_totalRepayment.HasValue)
                        CalculateTotalRepayment();                       
                    return _totalRepayment.Value;
                }
            }
        }

        public Tuple<int, int> Calculate(int remainingDebt)
        {
            int additionalDebt = remainingDebt * _interestRate;
            remainingDebt += (additionalDebt / 100) + (additionalDebt % 100 == 0 ? 0 : 1);
            int payment = remainingDebt * _repaymentRate;
            payment = (payment / 100) + (payment % 100 == 0 ? 0 : 1);
            if (payment <= MINIMUM_REPAYMENT)
                payment = MINIMUM_REPAYMENT;
            if (payment > remainingDebt)
                payment = remainingDebt;
            remainingDebt -= payment;
            return new Tuple<int, int>(remainingDebt, payment);
        }
    }
}
