import { Action,Reducer } from "redux";

export interface ProjectCardState{
    imageUrl: string,
    projectName: string,
    projectDescription: string,
    isLock:boolean
}

export interface LockProjectAction { type: 'LOCK_PROJECT' }
export interface UnlockProjectAction { type: 'UNLOCK_PROJECT' }

export type ProjectCardAction = LockProjectAction | UnlockProjectAction;

export const ProjectCardActionCreators = {
    lock: () => ({ type: 'LOCK_PROJECT' } as LockProjectAction),
    unlock: () => ({ type: 'UNLOCK_PROJECT' } as UnlockProjectAction)
}

export const reducer: Reducer<ProjectCardState> = (state: ProjectCardState | undefined, incomingAction: Action): ProjectCardState => {
    if (state === undefined) {
        return { imageUrl: "/default-project-card-icon.png", projectName: "Default", projectDescription: "null", isLock: false };
    }

    const action = incomingAction as ProjectCardAction;
    switch (action.type) {
        case 'LOCK_PROJECT':
            state.isLock = true;
            return state;
        case 'UNLOCK_PROJECT':
            state.isLock = false;
            return state;
        default:
            return state;
    }
}