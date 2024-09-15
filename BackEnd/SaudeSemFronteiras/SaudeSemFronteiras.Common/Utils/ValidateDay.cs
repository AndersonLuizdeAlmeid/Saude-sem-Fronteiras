using CSharpFunctionalExtensions;

namespace SaudeSemFronteiras.Common.Utils;
public class ValidateDay
{
    public static Result ValidateWorkingDay(DateOnly date, string workingDaysString)
    {
        // Criar uma lista dinâmica a partir da string recebida (ex: "012" -> segunda a quarta)
        var workingDays = new List<DayOfWeek>();

        foreach (var day in workingDaysString)
        {
            switch (day)
            {
                case '0': workingDays.Add(DayOfWeek.Monday); break;
                case '1': workingDays.Add(DayOfWeek.Tuesday); break;
                case '2': workingDays.Add(DayOfWeek.Wednesday); break;
                case '3': workingDays.Add(DayOfWeek.Thursday); break;
                case '4': workingDays.Add(DayOfWeek.Friday); break;
                case '5': workingDays.Add(DayOfWeek.Saturday); break;
                case '6': workingDays.Add(DayOfWeek.Sunday); break;
                default:
                    return Result.Failure("Formato inválido para os dias de trabalho.");
            }
        }

        // Verificar se o dia da semana da data está dentro dos dias de trabalho permitidos
        if (!workingDays.Contains(date.DayOfWeek))
        {
            return Result.Failure("A data selecionada não está dentro dos dias de trabalho permitidos.");
        }

        return Result.Success();
    }

}
