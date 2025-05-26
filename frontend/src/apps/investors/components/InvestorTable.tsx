import { type Investor } from "../../../shared/api/investorApi";
import DataTable, { type TableColumn } from 'react-data-table-component';
import { useNavigate } from "react-router-dom";

type Props = {
  data: Investor[];
};

const columns: TableColumn<Investor>[] = [
  { name: 'Id', selector: row => row.id, sortable: true },
  { name: 'Name', selector: row => row.name, sortable: true, right: true },
  { name: 'Investor Type', selector: row => row.type, sortable: true, right: true },
  { name: 'Date Added', selector: row => new Date(row.dateAdded).toLocaleDateString(), sortable: true, right: true },
  { name: 'Country', selector: row => row.country, sortable: true, right: true },
  { name: 'Total Commitment', selector: row => new Intl.NumberFormat('en', { notation: 'compact', compactDisplay: 'short',
}).format(row.totalCommitment), sortable: true, right: true },
];


export default function InvestorTable({ data }: Props) {
    const navigate = useNavigate();

  return (
    <DataTable
      columns={columns}
      data={data}
      pagination
      highlightOnHover
      pointerOnHover
      responsive
      onRowClicked={(row) => navigate(`/investorcommitments/${row.id}`)}
    />
  );
}
