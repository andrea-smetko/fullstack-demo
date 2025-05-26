export interface InvestorCommitments {
  id: number;
  assetClass: string;
  commitmentAmount: number;
  currency: string;
};

export async function fetchInvestorCommitments(investorId?: number): Promise<InvestorCommitments[]> {
  const res = await fetch(`http://localhost:5005/api/investorcommitments/${investorId ?? ""}`);
  if (!res.ok) throw new Error("Failed to fetch investor commitments");
  return await res.json();
}
