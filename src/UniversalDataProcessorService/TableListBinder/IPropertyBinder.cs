namespace UniversalDataProcessorService.TableListBinder
{
    public interface IPropertyBinder
    {
        BindingResult<TEntity> Bind<TEntity>(TEntity entity, IDictionary<string, object> values);

    }
}