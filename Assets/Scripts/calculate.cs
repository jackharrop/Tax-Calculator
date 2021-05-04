using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculate : MonoBehaviour
{
    public InputField GrossSalaryInput;
    public Dropdown SalaryPayPeriod;
    public Text MedicareOutput;
    public Text NetIncomeOutput;
    public Text IncomeTaxPaidOutput;


    public void claculate()
    {
        
    }

    private double ClaculateIncomeTax(double GrossYearlySalary)
    {
        if (GrossYearlySalary > 0 && GrossYearlySalary < 18200)
        {
            return 0;
        }
        else if (GrossYearlySalary < 37000)
        {
            return 0.19 * (GrossYearlySalary - 18200);
        }
        else if (GrossYearlySalary < 87000)
        {
            return 0.19 * (GrossYearlySalary - 18200);
        }
    }
    private double GrossYearlySalary()
    {
        if (double.TryParse(GrossSalaryInput.text, out double GetGrossSalary))
        {
            if (SalaryPayPeriod.value == 0)
            {
                return GetGrossSalary * 52;
            }
            else if (SalaryPayPeriod.value == 1)
            {
                return GetGrossSalary * 26;
            }
            else if (SalaryPayPeriod.value == 3)
            {
                return GetGrossSalary * 12;
            }
            else if (SalaryPayPeriod.value == 4)
            {
                return GetGrossSalary * 1;
            }



        }

    }
    
   
}

