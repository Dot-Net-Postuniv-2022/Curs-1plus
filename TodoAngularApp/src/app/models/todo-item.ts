export interface TodoItem {
    id?: number;
    name?: string;
    isComplete?: boolean;

    preparingDelete?: boolean;
    isEditing?: boolean;
}
