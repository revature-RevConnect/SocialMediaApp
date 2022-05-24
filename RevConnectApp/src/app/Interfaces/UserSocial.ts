export interface UserSocial{
    userID?: number;
    authID: any;
    name?: any,
    email?:any,
    profilePicture?: any,
    aboutMe?: string,
    phone?:any,
    address?:any,
    linkedin?:any,
    twitter?:any,
    github?:any,
    activer?:boolean,
  }
  
  export interface ChatUser {
    name?: string;
    connectionId?: string;
}