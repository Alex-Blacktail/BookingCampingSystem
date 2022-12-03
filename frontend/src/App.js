import {BrowserRouter, Route, Routes} from "react-router-dom";
import MainPage from "./pages/MainPage/MainPage";
import LoginPage from "./pages/LoginPage/LoginPage";
import RegPage from "./pages/RegisterPage/RegPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path={"/"} element={<MainPage/>}/>
        <Route path={"/login"} element={<LoginPage/>}/>
        <Route path={"/register"} element={<RegPage/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
