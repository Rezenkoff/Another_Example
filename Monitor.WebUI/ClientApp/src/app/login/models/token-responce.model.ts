import { UserResponseModel } from "./user-responce.model";

export class TokenResponse {
    constructor(
        public access_token: string,
        public expires_in: string,
        public success: boolean,
        public userData: UserResponseModel
    ) { }
}
