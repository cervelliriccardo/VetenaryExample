using System;
using System.ComponentModel;

namespace VetExample.Entities.Base
{
    /// <summary>
    /// Interface for the entity model. It gives access to common fields, at entity state, at tabel prefix, at validity state.
    /// Gives some functionality to ResetTransactionState, CloneSystemData, and raise event PropertyChanging and PropertyChanged  
    /// </summary>
    public interface IBaseEntity
    {
        bool inTxn { get; set; }
        DateTime? validityStartDate { get; set; }
        DateTime? validityEndDate { get; set; }
        int? lastModifiedBy { get; set; }
        DateTime? lastModifiedDate { get; set; }
        DateTime? deletedDate { get; set; }
        User lastModifiedByUser { get; set; }
        ObjectState CurrentState { get; set; }
        string TablePrefix { get; set; }
        bool isValid();
        void ResetTransactionState();
        void CloneSystemData(IBaseEntity cloned);
        event PropertyChangedEventHandler PropertyChanged;
        event PropertyChangingEventHandler PropertyChanging;
    }
}
