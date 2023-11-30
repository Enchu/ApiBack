using Backend.Models;
using Backend.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CalcController: ControllerBase
{
    private readonly ICalculatorRepository _calculatorRepository;
    public CalcController(ICalculatorRepository calculatorRepository)
    {
        _calculatorRepository = calculatorRepository;
    }
    
    [HttpGet("add")]
    public IActionResult Add(double num1, double num2)
    {
        Calculation result = _calculatorRepository.Add(num1, num2);
        return GetActionResult(result);
    }
    
    [HttpGet("subtract")]
    public IActionResult Subtract(double num1, double num2)
    {
        Calculation result = _calculatorRepository.Subtract(num1, num2);
        return GetActionResult(result);
    }
    
    [HttpGet("multiply")]
    public IActionResult Multiply(double num1, double num2)
    {
        Calculation result = _calculatorRepository.Multiply(num1, num2);
        return GetActionResult(result);
    }
    
    [HttpGet("divide")]
    public IActionResult Divide(double num1, double num2)
    {
        Calculation result = _calculatorRepository.Divide(num1, num2);
        return GetActionResult(result);
    }
    
    [HttpGet("pow")]
    public IActionResult Power(double num, double exponent)
    {
        Calculation result = _calculatorRepository.Power(num, exponent);
        return GetActionResult(result);
    }
    
    [HttpGet("sqrt")]
    public IActionResult SquareRoot(double num)
    {
        Calculation result = _calculatorRepository.SquareRoot(num);
        return GetActionResult(result);
    }
    
    [HttpGet("evaluate")]
    public IActionResult Evaluate(string expression)
    {
        Calculation result = _calculatorRepository.EvaluateExpression(expression);
        return GetActionResult(result);
    }
    
    private IActionResult GetActionResult(Calculation result)
    {
        if (!string.IsNullOrEmpty(result.ErrorMessage))
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result);
    }
}