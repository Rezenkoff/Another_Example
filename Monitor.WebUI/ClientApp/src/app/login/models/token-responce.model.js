"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var TokenResponse = /** @class */ (function () {
    function TokenResponse(access_token, expires_in, success, userData) {
        this.access_token = access_token;
        this.expires_in = expires_in;
        this.success = success;
        this.userData = userData;
    }
    return TokenResponse;
}());
exports.TokenResponse = TokenResponse;
//# sourceMappingURL=token-responce.model.js.map