using DataToTable;
using DataToTable.Unity;
using Log.Min.Data;
using Unity;

namespace Log.Min.Table;

public class LogTableSet 
    : DataToTableSet
{
    public LogTableSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .RegisterSingleton<IColumnCalculator<LogModel>, ColumnCalculator<LogModel>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .RegisterType<ITableTextEditor, TableTextEditor>()
            .RegisterSingleton<IDataToText<LogModel>, LogTableProvider>();
    }
}