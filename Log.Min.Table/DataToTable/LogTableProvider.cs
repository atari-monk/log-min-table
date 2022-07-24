using DataToTable;
using Log.Min.Data;

namespace Log.Min.Table;

public class LogTableProvider 
	: LogToColumn
{
	public LogTableProvider(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<LogModel> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected override void CreateTableHeader()
	{
		Editor.AddColumn(GetColumnData(nameof(LogModel.Id)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Start)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.End)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Time)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Description)));
	}

	protected override void CreateTableRow(LogModel l)
    {
        Editor.AddValue(GetColumnData(nameof(LogModel.Id)), GetId(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Start)), GetStart(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.End)), GetEnd(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Time)), GetTime(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Description)), GetDescription(l));
    }

    protected override void SetColumnsSize(List<LogModel> l)
	{
		SetColumn(nameof(LogModel.Id), GetIdLengths(l));
		SetColumn(nameof(LogModel.Start), GetStartLengths(l));
		SetColumn(nameof(LogModel.End), GetEndLengths(l));
		SetColumn(nameof(LogModel.Time), GetTimeLengths(l));
		SetColumn(nameof(LogModel.Description), GetDescriptionLengths(l));
	}   
}