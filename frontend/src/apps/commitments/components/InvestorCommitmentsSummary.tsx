import DataTable, { type TableColumn } from 'react-data-table-component';
import { type InvestorCommitments } from "../../../shared/api/investorCommitmentsApi";

type SummaryRow = {
  type: string;
  total: number;
};

type Props = {
  data: InvestorCommitments[];
  selectedType: string | null;
  onSelectType: (type: string | null) => void;
};

export default function SummaryTable({ data, selectedType, onSelectType }: Props) {
  const summaryData: SummaryRow[] = Object.entries(
    data.reduce((comm, curr) => {
      comm[curr.assetClass] = (comm[curr.assetClass] || 0) + curr.commitmentAmount;
      return comm;
    }, {} as Record<string, number>)
  ).map(([type, total]) => ({ type, total }));

  // Add 'All' option at the top
  summaryData.unshift({
    type: 'All',
    total: data.reduce((sum, comm) => sum + comm.commitmentAmount, 0),
  });

  const columns: TableColumn<SummaryRow>[] = [
    {
      name: 'Type',
      selector: row => row.type,
      sortable: true,
    },
    {
      name: 'Total Commitment',
      //selector: row => row.total.toFixed(2),
      selector : row => new Intl.NumberFormat('en', { notation: 'compact', compactDisplay: 'short',
}).format(row.total),
      sortable: true,
      right: true,
    },
  ];

  return (
    <DataTable
      columns={columns}
      data={summaryData}
      highlightOnHover
      pointerOnHover
      onRowClicked={(row) =>
        onSelectType(row.type === 'All' ? null : row.type)
      }
      dense
    />
  );
}
