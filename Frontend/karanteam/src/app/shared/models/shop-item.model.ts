export interface IShopItemModel {
    id: number;
    title: string;
    description?: string;
    imageUrl?: string;
    comments?: ICommentMondel[];
    ownerName?: string;
}

export interface ICommentMondel {
    id: number;
    ownerName: string;
    comment: string;
    date: Date;
}
