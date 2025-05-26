export interface Investor {
  id: number;
  name: string;
  totalCommitment: number;
  type: string;
  dateAdded: string;
  country: string;
};

export async function fetchInvestors(): Promise<Investor[]> {
  const res = await fetch("http://localhost:5005/api/investors");
  if (!res.ok) throw new Error("Failed to fetch investors");
  return await res.json();
}
