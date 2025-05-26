using CsvHelper.Configuration.Attributes;
public class SeedRecord
{
    [Name("Investor Name")]
    public string? InvestorName { get; set; }

    [Name("Investory Type")]
    public string? InvestorType { get; set; }

    [Name("Investor Country")]
    public string? InvestorCountry { get; set; }

    [Name("Investor Date Added")]
    public DateTime InvestorDateAdded { get; set; }

    [Name("Investor Last Updated")]
    public DateTime InvestorLastUpdated { get; set; }

    [Name("Commitment Asset Class")]
    public string? CommitmentAssetClass { get; set; }

    [Name("Commitment Amount")]
    public double CommitmentAmount { get; set; }

    [Name("Commitment Currency")]
    public string? CommitmentCurrency { get; set; }

}
