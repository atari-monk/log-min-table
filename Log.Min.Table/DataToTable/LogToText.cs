using DataToTable;
using Log.Min.Data;

namespace Log.Min.Table;

public abstract class LogToText
    : TextTable<LogModel>
{
	private const string DateTimeFormat = "dd.MM.yyyy HH:mm";
	private const string TimeFormat = "HH:mm";
	
    protected LogToText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<LogModel> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected string GetDescription(LogModel m) => 
		string.IsNullOrWhiteSpace(m.Description) == false ?
			m.Description : string.Empty;

	protected string GetId(LogModel m) => 
		m.Id.ToString();
	
    protected string GetStart(LogModel m) =>
		m.Start.HasValue ?
			m.Start.Value.ToString(DateTimeFormat) : string.Empty;

    protected string GetEnd(LogModel m) => 
		m.End.HasValue ?
			m.End.Value.ToString(TimeFormat) : string.Empty;

    protected string GetTime(LogModel m) => 
		$"{m.Time.Hours}:{m.Time.Minutes}";
}