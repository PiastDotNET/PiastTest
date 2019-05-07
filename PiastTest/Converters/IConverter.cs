namespace PiastTest.Converters
{
    public interface IConverter<TModel,TDto>
    {
        TModel Convert(TDto dto);
        TDto Convert(TModel model);
    }
}