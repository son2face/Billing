namespace Billing.Interfaces.ChargeLevels
{
    public interface IDeleteService
    {
        void DeleteFromDatabase(int level);
    }
}