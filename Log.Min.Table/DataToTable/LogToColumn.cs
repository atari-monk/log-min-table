using DataToTable;
using Log.Min.Data;

namespace Log.Min.Table;

public abstract class LogToColumn
    : LogToText
{
    protected LogToColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<LogModel> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

    protected List<int> GetIdLengths(List<LogModel> models)
	{
		var rows = models.Select(m => GetId(m).Length).ToList();
		rows.Insert(0, nameof(LogModel.Id).Length);
		return rows;
	}

    protected List<int> GetDescriptionLengths(List<LogModel> models)
	{
		var rows = models.Select(m => GetDescription(m).Length).ToList();
		rows.Insert(0, nameof(LogModel.Description).Length);
		return rows;
	}
    
	protected List<int> GetStartLengths(List<LogModel> models)
	{
		var rows = models.Select(e => GetStart(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.Start).Length);
		return rows;
	}

	protected List<int> GetEndLengths(List<LogModel> models)
	{
		var rows = models.Select(m => GetEnd(m).Length).ToList();
		rows.Insert(0, nameof(LogModel.End).Length);
		return rows;
	}

	protected List<int> GetTimeLengths(List<LogModel> models)
    {
		var rows = models.Select(m => GetTime(m).Length).ToList();
		rows.Insert(0, nameof(LogModel.Time).Length);
		return rows;
    }
}