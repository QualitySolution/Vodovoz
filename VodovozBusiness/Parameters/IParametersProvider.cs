﻿namespace Vodovoz.Parameters
{
    public interface IParametersProvider
    {
        bool ContainsParameter(string parameterName);
        void CreateOrUpdateParameter(string name, string value);
        string GetParameterValue(string parameterName);
        char GetCharValue(string parameterId);
        decimal GetDecimalValue(string parameterId);
        int GetIntValue(string parameterId);
        string GetStringValue(string parameterId);
        bool GetBoolValue(string parameterId);

        void RefreshParameters();
    }
}