using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculate : MonoBehaviour
{
    public InputField GrossSalaryInput;
    public Dropdown SalaryPayPeriodDropdown;
    public Text MedicareOutput;
    public Text NetIncomeOutput;
    public Text IncomeTaxPaidOutput;
    public Text GrossYearlySalaryOutput;


    public void calculates()
    {
        
         
        double grossSalaryInput = GetGrossSalary();
        string SalaryPayPeriod = GetSalaryPayPeriod();
        
        double MedicareLevyPaid = CalculateMedicareLevy(grossSalaryInput);

        double grossYearlySalary = CalculateGrossYearlySalary( grossSalaryInput, SalaryPayPeriod);
        
        double IncomeTaxPaid = CalculateIncomeTax(grossYearlySalary);

        double NetIncome = CalculateNetIncome( grossYearlySalary, ref MedicareLevyPaid, ref IncomeTaxPaid);
        

        OutputResults(MedicareLevyPaid, IncomeTaxPaid, NetIncome, grossYearlySalary);
        //output
    }

   
    private double GetGrossSalary()
    {
        double GrossSalary = double.Parse(GrossSalaryInput.text);
        return GrossSalary;
    }
    private string GetSalaryPayPeriod()
    {
        if (SalaryPayPeriodDropdown.value == 0)
        {
            return "Weekly";
        }
        else if (SalaryPayPeriodDropdown.value == 1)
        {
            return "Fortnightly";
        }
        else if (SalaryPayPeriodDropdown.value == 0)
        {
            return "Monthly";
        }
        else 
        {
            return "Yearly";
        }
    }

    private double CalculateGrossYearlySalary(double grossSalaryInput, string SalaryPayPeriod)
    {
        if(SalaryPayPeriod == "Weekly")
        {
            return grossSalaryInput * 52;
        }
        else if (SalaryPayPeriod == "Fortnightly")
        {
            return grossSalaryInput * 26;
        }
        else if (SalaryPayPeriod == "Monthly")
        {
            return grossSalaryInput * 12;
        }
        else
        {
            return grossSalaryInput * 1;
        }
    }

    private double CalculateIncomeTax(double grossYearlySalary)
    {
        if (grossYearlySalary > 0 && grossYearlySalary < 18200)
        {
            return 0;
        }
        else if (grossYearlySalary < 37000)
        {
            return 0.19 * (grossYearlySalary - 18200);
        }
        else if (grossYearlySalary < 87000)
        {
            return 3573 + 0.325 * (grossYearlySalary - 37000);
        }
        else if (grossYearlySalary < 180000)
        {
            return 19822 + 0.37 * (grossYearlySalary - 87000);
        }
        else if (grossYearlySalary > 180000)
        {
            return 54232 + 0.45 * (grossYearlySalary - 18000);
        }
        else
        {
            return 0;
        }
    }
    private double CalculateMedicareLevy(double grossYearlySalary)
    {
        return grossYearlySalary * 0.02;
    }
    private double CalculateNetIncome(double grossYearlySalary , ref double MedicareLevyPaid, ref double IncomeTaxPaid)
    {
        return grossYearlySalary - MedicareLevyPaid - IncomeTaxPaid;
    }
    private void OutputResults(double MedicareLevyPaid, double IncomeTaxPaid, double NetIncome, double grossYearlySalary)
    {
        MedicareOutput.text = "Medicare levy paid: $" + MedicareLevyPaid.ToString("F2");
        NetIncomeOutput.text = "Net income paid: $" + NetIncome.ToString("F2");
        GrossYearlySalaryOutput.text = "Gross salary paid: $" + grossYearlySalary.ToString("F2");
        IncomeTaxPaidOutput.text = "Income tax paid: $" + IncomeTaxPaid.ToString("F2");

    }


}

