export const apiRoutes = {
  post: {
    registerSuperAdmin: "/api/authentication/register/superadmin",
    registerParent: "/api/authentication/register/parent",
    login: "/api/authentication/login",
    addCampCard: "/api/camp/addcampcard",
    addChildrenInfo: "/api/child/addchildinfo",
    addRole: "/api/Roles/AddRole",
    editUserRole: "/api/Roles/EditUserRole",
  },
  get: {
    campCards:'/api/camp/campcards',
    parentInfo: '/api/parentlookup/parentlookupinfo/',
    userRole: '/api/Roles/GetUserRoles',
    initRoles: '/api/Roles/Initialize'
  },
  delete:{
    child: '/api/child/removechildinfo',
    roleId: '/api/Roles/DeleteRole'
  }
};
