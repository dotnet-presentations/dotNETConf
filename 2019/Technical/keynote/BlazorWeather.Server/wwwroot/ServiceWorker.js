const baseURL = '/';
const indexURL = '/Pages/_Host.cshtml';
const networkFetchEvent = 'fetch';
const swInstallEvent = 'install';
const swInstalledEvent = 'installed';
const swActivateEvent = 'activate';
self.addEventListener(networkFetchEvent, event => {
    return fetch(event.request);
});
