import {BrowserRouter, Route, Routes} from "react-router-dom";
import MainPage from "./pages/MainPage/MainPage";
import LoginPage from "./pages/LoginPage/LoginPage";
import RegPage from "./pages/RegisterPage/RegPage";
import {ROUTES} from "./constants/routes";
import {AuthContext} from "./context";
import {useEffect, useState} from "react";
import Cookies from 'js-cookie'
import ParentProfile from "./pages/profile/ParentProfile/ParentProfile";
import Catalog from "./pages/Сatalog/Catalog";
import CampCardPage from "./pages/CampCardPage/CampCardPage";
import {SnackbarProvider} from "notistack";
import LocalAdminProfile from "./pages/profile/LocalAdminProfile/LocalAdminProfile";

function App() {

  const [userInfo, setUserInfo] = useState()

  const token = Cookies.get('token')
  const userId = Cookies.get('userId')
  const role = Cookies.get('role')

  useEffect(() => {
    if (token && userId && role){
      setUserInfo({
        token, userId, role
      })
      console.log('logged')
    }
  },[])

  return (
   <AuthContext.Provider value={{
     userInfo,
     setUserInfo
   }}
   >
    <SnackbarProvider maxSnack={3}>
      <BrowserRouter>
        <Routes>
          {
            userInfo ?
              <>

              </>
              :
              <>

              </>
          }
          <Route path={ROUTES.catalog} element={<Catalog/>}/>
          <Route path={ROUTES.login} element={<LoginPage/>}/>
          <Route path={ROUTES.register} element={<RegPage/>}/>
          <Route path={ROUTES.profile} element={<ParentProfile/>}/>
          <Route path={ROUTES.index} element={<MainPage/>}/>
          <Route path={ROUTES.campPage} element={<CampCardPage/>}/>
          <Route path={ROUTES.admin} element={<LocalAdminProfile/>}/>
        </Routes>
      </BrowserRouter>
    </SnackbarProvider>
   </AuthContext.Provider>
  );
}

export default App;
