public class ElementDamageMultiplierCalculator
{
    public static float Get(ElementType offender, ElementType defender)
    {
        if (offender == defender)
        {
            return 1f;
        }

        if (offender == ElementType.Fire)
        {
            if (defender == ElementType.Wind)
            {
                return Constants.ElementDamageEnhanceMultiplier;
            }
            else if (defender == ElementType.Water)
            {
                return Constants.ElementDamageReduceMultiplier;
            }
        }
        else if (offender == ElementType.Water)
        {
            if (defender == ElementType.Fire)
            {
                return Constants.ElementDamageEnhanceMultiplier;
            }
            else if (defender == ElementType.Earth)
            {
                return Constants.ElementDamageReduceMultiplier;
            }
        }
        else if (offender == ElementType.Earth)
        {
            if (defender == ElementType.Water)
            {
                return Constants.ElementDamageEnhanceMultiplier;
            }
            else if (defender == ElementType.Wind)
            {
                return Constants.ElementDamageReduceMultiplier;
            }
        }
        else if (offender == ElementType.Wind)
        {
            if (defender == ElementType.Earth)
            {
                return Constants.ElementDamageEnhanceMultiplier;
            }
            else if (defender == ElementType.Fire)
            {
                return Constants.ElementDamageReduceMultiplier;
            }
        }

        return 1f;
    }
}