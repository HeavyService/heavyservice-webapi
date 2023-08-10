namespace HeavyService.Persistance.Validations;

public class PhoneNumberValidotor
{
    public static bool IsValid(string phonenumber)
    {
        if (phonenumber.Length != 13) return false;

        if (phonenumber.StartsWith("+998") == false) return false;

        for (int i = 1; i < phonenumber.Length; i++)
        {
            if (char.IsDigit(phonenumber[i])) continue;
            else return false;
        }

        return true;
    }
}
