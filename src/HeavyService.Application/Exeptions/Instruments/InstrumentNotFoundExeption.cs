namespace HeavyService.Application.Exeptions.Instruments;

public class InstrumentNotFoundExeption : NotFoundExeption
{
    public InstrumentNotFoundExeption()
    {
        this.TitleMessage = "Instrument not found!";
    }
}
