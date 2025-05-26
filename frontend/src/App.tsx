import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import InvestorPage from "./apps/investors/pages/InvestorPage";
import InvestorCommitmentsPage from "./apps/commitments/pages/InvestorCommitmentsPage";


export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/investors" />} />
        <Route path="/investors" element={<InvestorPage />} />
        <Route path="/investorcommitments/:investorId" element={<InvestorCommitmentsPage />} />
      </Routes>
    </Router>
  );
}
