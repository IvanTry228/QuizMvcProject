using System.Data;

namespace Quick_Quiz.QuizTemplate
{
    public interface ISetDataByDataTable
    {
        void SetData(DataTable _dataTable);
    }

    public interface ISetDataByDataRow
    {
        void SetData(DataRow _dataTable);
    }
}
