export interface IShopItemModel {
    id: number;
    title: string;
    description?: string;
    imageUrl?: string;
    fileComments?: ICommentMondel[];
    ownerName?: string;
}

export interface INewShopItemModel {
    title: string;
    description: string;
    file: File;
}

export interface ICommentMondel {
    id: number;
    ownerName: string;
    content: string;
    creationDate: Date;
}
