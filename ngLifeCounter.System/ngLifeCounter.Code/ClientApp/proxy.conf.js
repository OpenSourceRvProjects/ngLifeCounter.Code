const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:34973';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api/Account/signUp",
      "/api/Account/login",
      "/api/Account/resetPassword",
      "/api/Account/changePasswordWithURL",
      "/api/Account/validateRecoveryRequestID",
      "/api/EventCounter",
      "/api/EventCounter/getById",
      "/api/EventCounter/getCountersResume",
      "/api/Environment",
      "/api/EventCounter/changeCounterPrivacy",
      "/api/EventCounter/editCounterEvent",
      "/api/Profile/getImages",
      "/api/Profile/addImages",
      "/api/Admin/getAllUsers",
      "/api/Account/impersonate",
      "/api/Profile/getProfileData",
      "/api/Relapses/getEventCounterRelapses"

   ],
    proxyTimeout: 100000,
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
