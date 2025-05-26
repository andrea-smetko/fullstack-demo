import { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import { fetchInvestorCommitments, type InvestorCommitments } from "../../../shared/api/investorCommitmentsApi";
import InvestorCommitmentsTable from "../components/InvestorCommitmentsTable";
import SummaryTable from "../components/InvestorCommitmentsSummary";

export default function InvestorCommitmentsListPage() {
  const [data, setData] = useState<InvestorCommitments[]>([]);
  const [loading, setLoading] = useState(true);
  const { investorId } = useParams();

  const parsedId = investorId && !isNaN(Number(investorId)) ? Number(investorId) : undefined;
  const [selectedType, setSelectedType] = useState<string | null>(null);


    useEffect(() => {
    fetchInvestorCommitments(parsedId)
    .then((data) => {
      console.log("Fetched commitments:", data); 
      setData(data);
    })
    .catch((err) => console.error(err))
    .finally(() => setLoading(false));
  }, [investorId]);

  const filteredData = selectedType ? data.filter(a => a.assetClass === selectedType) : data;

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Investor Commitments</h1>
      <SummaryTable data={data}
      selectedType={selectedType}
      onSelectType={setSelectedType}
    />
      {loading ? (
        <p>Loading...</p>
      ) : (
        <InvestorCommitmentsTable data={filteredData} />
      )}
    </div>
  );
}
