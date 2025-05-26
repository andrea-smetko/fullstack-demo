import { useEffect, useState } from "react";
import { fetchInvestors, type Investor } from "../../../shared/api/investorApi";
import InvestorTable from "../components/InvestorTable";

export default function InvestorListPage() {
  const [data, setData] = useState<Investor[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchInvestors()
      .then(setData)
      .finally(() => setLoading(false));
  }, []);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Investors</h1>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <InvestorTable data={data} />
      )}
    </div>
  );
}
