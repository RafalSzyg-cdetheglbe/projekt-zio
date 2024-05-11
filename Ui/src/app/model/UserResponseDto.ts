export interface UserResponseDTO {
    id: number;
    name: string;
    userType: UserType;
    isActive: boolean;
}

export enum UserType {
    Admin = 0,
    Moderator = 1,
    Guest = 2
}