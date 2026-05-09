import {Navigate, Route, Routes} from "react-router";
import './App.css'
import HomePage from "./pages/HomePage.tsx";
import LinkPage from "./pages/LinkPage.tsx";

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage/>}/>
      <Route path="/l/:shortCode" element={<LinkPage/>}/>
      <Route path="*" element={<Navigate to="/"/>}/>
    </Routes>
  );
}
