using AngouriMath;
using Backend.Models;
using Backend.Repositories.Interface;
using NCalc;
using Expression = NCalc.Expression;

namespace Backend.Repositories;

public class CalculatorRepository: ICalculatorRepository
{
    public Calculation Add(double num1, double num2)
    {
        return new Calculation
        {
            Operand1 = num1,
            Operand2 = num2,
            Result = num1 + num2,
            Operation = OperationType.Add
        };
    }

    public Calculation Subtract(double num1, double num2)
    {
        return new Calculation
        {
            Operand1 = num1,
            Operand2 = num2,
            Result = num1 - num2,
            Operation = OperationType.Subtract
        };
    }

    public Calculation Multiply(double num1, double num2)
    {
        return new Calculation
        {
            Operand1 = num1,
            Operand2 = num2,
            Result = num1 * num2,
            Operation = OperationType.Multiply
        };
    }

    public Calculation Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            return new Calculation
            {
                Operand1 = num1,
                Operand2 = num2,
                ErrorMessage = "Cannot divide by zero",
                Operation = OperationType.Divide
            };
        }

        return new Calculation
        {
            Operand1 = num1,
            Operand2 = num2,
            Result = num1 / num2,
            Operation = OperationType.Divide
        };
    }

    public Calculation Power(double num, double exponent)
    {
        return new Calculation
        {
            Operand1 = num,
            Operand2 = exponent,
            Result = Math.Pow(num, exponent),
            Operation = OperationType.Power
        };
    }

    public Calculation SquareRoot(double num)
    {
        if (num < 0)
        {
            return new Calculation
            {
                Operand1 = num,
                ErrorMessage = "Cannot calculate square root of a negative number",
                Operation = OperationType.SquareRoot
            };
        }

        return new Calculation
        {
            Operand1 = num,
            Result = Math.Sqrt(num),
            Operation = OperationType.SquareRoot
        };
    }

    public Calculation EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            return new Calculation
            {
                Expression = expression,
                ErrorMessage = "Выражение не задано или некорректно"
            };
        }
        
        try
        {
            Entity expr = expression;
            
            Entity result = expr.Simplify();

            return new Calculation
            {
                Expression = expression,
                Result = (double)result.EvalNumerical(),
                Operation = OperationType.CustomExpression
            };
        }
        catch (Exception ex)
        {
            return new Calculation
            {
                Expression = expression,
                ErrorMessage = $"Ошибка при вычислении выражения: {ex.Message}"
            };
        }
    }
}