using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TotalGameManager : UnitySingleton<TotalGameManager>
{
    [SerializeField] private MechSpecifications MechData = null;
    private MechSpec _selectedMech = null;

    void SetPlayerMech(int mechId)
    {
        _selectedMech = GetMechDataById(mechId);
    }
    
    MechSpec GetMechDataById(int mechId)
    {
        var data = MechData.MechSpecs
            .First(x => x.mechId == mechId);

        return data;
    }

    MechSpecifications GetMechDataMaster()
    {
        return MechData;
    }
}
