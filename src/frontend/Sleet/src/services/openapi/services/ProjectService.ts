/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Project } from '../models/Project';
import { request as __request } from '../core/request';

export class ProjectService {

    /**
     * @returns Project Success
     * @throws ApiError
     */
    public static async getProjectService(): Promise<Array<Project>> {
        const result = await __request({
            method: 'GET',
            path: `/Project`,
        });
        return result.body;
    }

}