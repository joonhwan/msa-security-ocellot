
var config = {
    authority: "https://localhost:5001/",
    client_id: "js_oidc",
    redirect_uri: window.location.origin + "/callback.html",
    post_logout_redirect_uri: window.location.origin + "/index.html",

    // if we choose to use popup window instead for logins
    popup_redirect_uri: window.location.origin + "/popup.html",
    popupWindowFeatures: "menubar=yes,location=yes,toolbar=yes,width=1200,height=800,left=100,top=100;resizable=yes",

    // these two will be done dynamically from the buttons clicked, but are
    // needed if you want to use the silent_renew
    response_type: "code",
    scope: "openid profile email resource1.scope1 resource2.scope1",

    // this will toggle if profile endpoint is used
    loadUserInfo: true,

    // silent renew will get a new access_token via an iframe 
    // just prior to the old access_token expiring (60 seconds prior)
    silent_redirect_uri: window.location.origin + "/silent.html",
    automaticSilentRenew: true,

    monitorAnonymousSession: true,

    // will revoke (reference) access tokens at logout time
    revokeAccessTokenOnSignout: true,

    // this will allow all the OIDC protocol claims to be visible in the window. normally a client app 
    // wouldn't care about them or want them taking up space
    filterProtocolClaims: false
};