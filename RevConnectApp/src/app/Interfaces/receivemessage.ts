export interface ReceiveMessage {
    receiver: string;
    sender: string;
    message: string;
    isSender: boolean;
}