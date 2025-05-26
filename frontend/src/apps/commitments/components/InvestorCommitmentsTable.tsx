import { type InvestorCommitments } from "../../../shared/api/investorCommitmentsApi";
import DataTable, { type TableColumn } from 'react-data-table-component';

type Props = {
  data: InvestorCommitments[];
};

const columns: TableColumn<InvestorCommitments>[] = [
  { name: 'Id', selector: row => row.id, sortable: true,  },
  { name: 'Asset Class', selector: row => row.assetClass, sortable: true, right: true },
  { name: 'Currency', selector: row => row.currency, sortable: true, right: true },
  { name: 'Commitment Amount', selector: row =>  new Intl.NumberFormat('en', { notation: 'compact', compactDisplay: 'short',
}).format(row.commitmentAmount), sortable: true, right: true },
  ];

export default function InvestorCommitmentsTable({ data }: Props) {
  return (
    <DataTable
      title = "Commitments breakdow by Asset Class"
      columns={columns}
      data={data}
      pagination
      highlightOnHover
      pointerOnHover
      responsive
    />
  );
}
