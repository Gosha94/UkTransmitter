using System.Threading.Tasks;

namespace UkTransmitter.Domain.Contracts
{

    /// <summary>
    /// Интерфейс, описывающий будущий доменный бизнес-процесс
    /// </summary>
    public interface IBusinessWorkflow
    {

        /// <summary>
        /// Старт работы процесса
        /// </summary>
        Task StartWorkflow();

        /// <summary>
        /// Остановка работы процесса
        /// </summary>
        Task StopWorkflow();

    }
}