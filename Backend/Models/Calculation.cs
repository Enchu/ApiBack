namespace Backend.Models;

public enum OperationType
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Power,
    SquareRoot,
    CustomExpression
}

public class Calculation
{
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    public double Result { get; set; }
    public OperationType Operation { get; set; }
    public string Expression { get; set; }
    public string ErrorMessage { get; set; }
}