using Backend.Models;

namespace Backend.Repositories.Interface;

public interface ICalculatorRepository
{
    Calculation Add(double num1, double num2);
    Calculation Subtract(double num1, double num2);
    Calculation Multiply(double num1, double num2);
    Calculation Divide(double num1, double num2);
    Calculation Power(double num, double exponent);
    Calculation SquareRoot(double num);
    Calculation EvaluateExpression(string expression);
}