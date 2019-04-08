using System;
					
public class Program
{
	public static void Main()
	{
		var salary= new Salary();
		
        //TESTs
		if (salary.calculateCompensation(150000,11) == 0) { TestOK();} else { TestERROR();}
        if (salary.calculateCompensation(150000,12) == 150000) { TestOK();} else { TestERROR();}
		if (salary.calculateCompensation(150000,17) == 150000) { TestOK();} else { TestERROR();}
		if (salary.calculateCompensation(150000,18) == 300000) { TestOK();} else { TestERROR();}
		if (salary.calculateCompensation(150000,19) == 300000) { TestOK();} else { TestERROR();}
        if (salary.calculateCompensation(150000,30) == 450000) { TestOK();} else { TestERROR();}
		
		// 90 UFs X 27565 = 2480850
		if (salary.calculateCompensation(4000000,11,2480850) == 0) { TestOK();} else { TestERROR();}
        if (salary.calculateCompensation(4000000,12,2480850) == 2480850) { TestOK();} else { TestERROR();}
		if (salary.calculateCompensation(4000000,17,2480850) == 2480850) { TestOK();} else { TestERROR();}
		if (salary.calculateCompensation(4000000,18,2480850) == 4961700) { TestOK();} else { TestERROR();}
		if (salary.calculateCompensation(4000000,19,2480850) == 4961700) { TestOK();} else { TestERROR();}
        if (salary.calculateCompensation(4000000,30,2480850) == 7442550) { TestOK();} else { TestERROR();}
	
		
		Console.WriteLine(salary.calculateCompensation(0,0));
		
		//getSalaryBaseCalculate();
		
	}
	
	private static void TestOK(){
		testMessage("OK");
	}
	private static void TestERROR(){
		testMessage("ERROR");
	}
	private static void testMessage(string type){
		Console.WriteLine("Test " + type + ".");
	}
 
}

public class Salary{
  
  private double salaryExtraFactor = 6;
 
  public decimal calculateCompensation (decimal salaryEmployee, decimal workedMonthsEmployee, decimal maxSalaryToRecibeByLaw = 0){
  
	int salaryCompensation = 0 ;  

    verifyZero(salaryEmployee, "salary employee");
    verifyZero(workedMonthsEmployee, "worked months");
    
    if (workedMonthsEmployee < 12){
      return salaryCompensation;
    }

    decimal salaryBaseCalculate = getSalaryBaseCalculate(salaryEmployee, maxSalaryToRecibeByLaw);
    salaryCompensation = (int)(workedMonthsEmployee / 12) ;
    double rest = (double)(workedMonthsEmployee%12);
    
    if (rest >= salaryExtraFactor){
      salaryCompensation++;
    }
    
    return salaryCompensation * salaryBaseCalculate;
  }
  
  public decimal getSalaryBaseCalculate(decimal salaryEmployee, decimal maxSalaryToRecibeByLaw){
	decimal salaryBaseCalculate = 0;
	if (maxSalaryToRecibeByLaw != 0 && salaryEmployee > maxSalaryToRecibeByLaw) {
      salaryBaseCalculate = maxSalaryToRecibeByLaw;
    }else {
      salaryBaseCalculate = salaryEmployee;
    }
	  
	return salaryBaseCalculate;
  }
	
  private void verifyZero(decimal number, string messageException){
     if (number == 0) {
         throw new Exception ("The " + messageException + " cannot be zero");
     }
  }
}
