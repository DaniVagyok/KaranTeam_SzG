export interface IShopItemModel {
    id: number;
    title: string;
    description?: string;
    imageUrl?: string;
    fileComments?: ICommentMondel[];
    ownerName?: string;
}

export interface ICommentMondel {
    id: number;
    ownerName: string;
    content: string;
    creationDate: Date;
}
