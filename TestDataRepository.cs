using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class TestDataRepository
{
    public IEnumerable<LoginTestData> GetLoginTestData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<LoginTestData>().ToList();
        }
    }

    public IEnumerable<CheckoutTestData> GetCheckoutTestData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<CheckoutTestData>().ToList();
        }
    }
}

public class LoginTestData
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class CheckoutTestData
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string zipCode { get; set; }
}
