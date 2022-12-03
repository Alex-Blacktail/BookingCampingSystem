import {BrowserRouter, Route, Routes} from "react-router-dom";
import MainPage from "./pages/MainPage/MainPage";
import LoginPage from "./pages/LoginPage/LoginPage";
import RegPage from "./pages/RegisterPage/RegPage";
import {ROUTES} from "./constants/routes";
import {AuthContext} from "./context";
import {useEffect, useState} from "react";
import Cookies from 'js-cookie'
import ParentProfile from "./pages/profile/ParentProfile/ParentProfile";

function App() {

  const [userInfo, setUserInfo] = useState()

  const token = Cookies.get('token')

  useEffect(() => {
    if (token){
      setUserInfo((prevState) => ({...prevState, token}))
      console.log('logged')
    }
  },[])

  return (
   <AuthContext.Provider value={{
     userInfo,
     setUserInfo
   }}
   >
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
         <Route path={ROUTES.login} element={<LoginPage/>}/>
         <Route path={ROUTES.register} element={<RegPage/>}/>
         <Route path={ROUTES.parentProfile} element={<ParentProfile/>}/>
         <Route path={ROUTES.index} element={<MainPage/>}/>
       </Routes>
     </BrowserRouter>
   </AuthContext.Provider>
  );
}

export default App;
