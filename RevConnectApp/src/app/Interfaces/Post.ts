export interface Post{
    postID?:number;
    title:string;
    body:string;
    authID:string;
    postLikes?:any;
    postComments?:any;
}